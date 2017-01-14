using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using AutoServer.Common;
using System.Runtime.Serialization.Json;
using static WApp.Models.ELMADBModels;
using WApp.Models;

namespace WApp.Managers
{
    /// <summary>
    /// Менеджер синхронизации с Elma
    /// </summary>
    public class ElmaConnectManager
    {
        /// <summary>
        /// С какой Элмой будем авторизовыаться.
        /// </summary>
        /// <param name="elmaId"></param>
        public ElmaConnectManager(long elmaId) {
            ElmaId = elmaId;
        }
        private static string ApplicationToken = "099DE4CCB2B3719542080861A3FAC86E6397D1FE71A0D637D85E6220AD33D7A40FD1404841F30DB78867187CB0A08D34712398021F77BDA7745ADB79D377B246";
        private static string authToken;
        private static string SessionToken;
        private static string ServerName= "w1003:8000";
        private static string LoginName = "admin";
        private static string Password = "";
        private static long ElmaId = 0;



        /// <summary>
        /// Синхронизация с элмой
        /// </summary>
        public void Sync() {
            ConnectElma();
            syncTask();


        }

        /// <summary>
        /// Проверка коннекта к элме
        /// 
        /// </summary>
        private bool CheckConnectElma()
        {
            return true;
            //создаем веб запрос
            System.Net.HttpWebRequest req = WebRequest.Create(String.Format("http://{0}/API/REST/Authorization/CheckToken?token={1}", ServerName, ApplicationToken)) as HttpWebRequest;
            req.Headers.Add("ApplicationToken", ApplicationToken);
            req.Method = "POST";
            req.Timeout = 10000;
            req.ContentType = "application/json; charset=utf-8";
            //данные для отправки. используется для передачи пароля. пароль нужно записать вместо пустой строки
            var sentData = Encoding.UTF8.GetBytes("");
            req.ContentLength = sentData.Length;
            Stream sendStream = req.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);

            //получение ответа
            var res = req.GetResponse() as System.Net.HttpWebResponse;
            var resStream = res.GetResponseStream();
            var sr = new StreamReader(resStream, Encoding.UTF8);
            var se = sr.ReadToEnd();
            return true;
        }

   
        /// <summary>
        /// Автризация в элму
        /// </summary>
        private void ConnectElma()
        {
             if (CheckConnectElma()) {

             } 
            //создаем веб запрос
            var srtAuth = String.Format("http://{0}/API/REST/Authorization/LoginWith?username={1}", ServerName, LoginName);
            System.Net.HttpWebRequest req = WebRequest.Create(srtAuth) as HttpWebRequest;
            req.Headers.Add("ApplicationToken", ApplicationToken);
            req.Method = "POST";
            req.Timeout = 10000;
            req.ContentType = "application/json; charset=utf-8";

            //данные для отправки. используется для передачи пароля. пароль нужно записать вместо пустой строки
            var sentData = Encoding.UTF8.GetBytes(Password);
            req.ContentLength = sentData.Length;
            Stream sendStream = req.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);

            //получение ответа
            var res = req.GetResponse() as System.Net.HttpWebResponse;
            var resStream = res.GetResponseStream();
            var sr = new StreamReader(resStream, Encoding.UTF8);

            var s = sr.ReadToEnd();
            //достаем необходимые данные

            // var dict = new JsonSerializer().Deserialize(sr.ReadToEnd(), typeof(Dictionary<string, string>)) as Dictionary<string, string>;
            var dict = new JsonSerializer();
            var dictA = dict.DeserializeObject(s);// as Dictionary<string, string>;
            var dictB = dictA  as Dictionary<string, object>;
             authToken =(string) dictB["AuthToken"];
             SessionToken = (string)dictB["SessionToken"];
        }

        private void syncTask() {
            var typeUid = "37b38fe1-1ca9-40f2-aa20-18ea04ccd3a9";
            var eqlQuery = "";
            var limit = "15";
            var offset = "0";
            var sort = "";
            var filterProviderUid = "";
            var filterProviderData = "";
            var filter = "";
            //var str = String.Format(@"http://{8}/API/REST/Entity/Query?type={0}&q={1}&limit={2}&offset={3}&sort={4}&filterProviderUid={5}&filterProviderData={6}&filter={7}",
                var str = String.Format(@"http://{8}/API/REST/Entity/Query?type={0}&limit={2}&offset={3}",
            typeUid, eqlQuery, limit, offset, sort, filterProviderUid, filterProviderData, filter, ServerName);
            HttpWebRequest queryReq = WebRequest.Create(str) as HttpWebRequest;
            queryReq.Method = "GET";
            queryReq.Headers.Add("AuthToken", authToken);
            queryReq.Headers.Add("SessionToken", SessionToken);
            queryReq.Timeout = 10000;
            queryReq.ContentType = "application/json; charset=utf-8";

            var res = queryReq.GetResponse() as HttpWebResponse;
            var resStream = res.GetResponseStream();
            var sr = new StreamReader(resStream, Encoding.UTF8);

            var s = sr.ReadToEnd();
            //достаем необходимые данные
            //Newtonsoft.Json.Linq.JObject obj = Newtonsoft.Json.Linq.JObject.Parse(s);
            //DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(object[]));
            //object objResponse = jsonSerializer.ReadObject(resStream);

            // var dict = new JsonSerializer().Deserialize(sr.ReadToEnd(), typeof(Dictionary<string, string>)) as Dictionary<string, string>;
            var dict = new JsonSerializer();
            //var s = "";
            var dictA = dict.DeserializeObject(s);// as Dictionary<string, string>;
            var dictB = dictA as object[];
            if (dictB != null) {
                foreach (var dictC in dictB) {
                    var value = dictC as Dictionary<string, object>;
                    var items = value["Items"];
                    var params1=items as object[];
                    // Создать объект контекста
                    WorkflowInstance instance = new WorkflowInstance();
                    foreach (var param in params1)
                    {
                        var p1 = param as Dictionary<string, object>;
                        if (p1.ContainsKey("Name")) {
                            var name = p1["Value"];
                            if (name == "Id") {
                                instance.id = int.Parse((string)p1["Value"]);
                            }

                            
                        }
                    

                        
                    }
                    // Создать объект контекста
                    ELMADBContext context = new ELMADBContext();
                    // Вставить данные в таблицу Customers с помощью LINQ
                    context.WorkflowInstance.Add(instance);

                    // Сохранить изменения в БД
                    context.SaveChanges();

                }
            }
            Console.ReadKey();
        }

    }
}