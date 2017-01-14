function makeSeries(listOfData) {
    var sumX = 0.0;
    for (var i = 0; i < listOfData.length; i++) {
        sumX += listOfData[i].x;
    }
    var gap = sumX / rawData.length * 0.0;
    var allSeries = []
    var x = 0.0;
    for (var i = 0; i < listOfData.length; i++) {
        var data = listOfData[i];
        allSeries[i] = {
            name: data.name,
            data: [
                [x, 0], [x, data.y],
                {
                    x: x + data.x / 2.0,
                    y: data.y,
                    dataLabels: { enabled: true, format: data.x + ' x {y}' }
                },
                [x + data.x, data.y], [x + data.x, 0]
            ],
            w: data.x,
            h: data.y
        };
        x += data.x + gap;
    }
    return allSeries;
}
    