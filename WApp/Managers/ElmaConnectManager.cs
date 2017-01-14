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
            var authToken = dictB["AuthToken"];
            var sessionToken = dictB["SessionToken"];
        }


    }
}