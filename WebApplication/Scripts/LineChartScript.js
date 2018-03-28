function buildLineChart(firstList, secondList, label, elementId) {
    
    var LineChartData =
            {
                labels: firstList,
                datasets: [{
                    label: label,
                    backgroundColor: "rgba(75,192,192,0.4)",
                    borderWidth: 2,
                    data: secondList
                }]
            };

    window.onload = function () {
        var ctx1 = document.getElementById(elementId).getContext("2d");
        window.myBar = new Chart(ctx1,
            {
                type: 'line',
                data: LineChartData,
                options:
                    {
                        title:
                        {
                            display: true,
                            text: label
                        },
                        responsive: true,
                        maintainAspectRatio: true
                    }
            });
    }

}