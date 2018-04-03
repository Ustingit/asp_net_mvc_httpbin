function buildLineChart(firstList, secondList, x_labels, chart_label, elementId) {
    
    var LineChartData =
            {
                labels: x_labels,
                datasets: [
                    {
                        label: "Common Responses",
                        backgroundColor: "rgba(75,192,192,0.4)",
                        borderWidth: 2,
                        data: firstList
                    },
                    {
                        label: "Delayed Responses",
                        backgroundColor: "rgba(75,192,192,0.4)",
                        borderWidth: 2,
                        data: secondList
                    }
                ]
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
                            text: chart_label
                        },
                        responsive: true,
                        maintainAspectRatio: true
                    }
            });
    }

}

function buildLineChartAjax(url, elementId) {
    $.ajax({
        type: "post",
        url: url,
        contentType: "application/json; charset=utf-8",
        updateTargetId: elementId,
        dataType: "json",
        success:
        function (result) {
            var ctx1 = document.getElementById(elementId).getContext("2d");
            window.myBar = new Chart(ctx1, {
                type: 'line',
                data: {
                    labels: result.ContentIds,
                    datasets: [{
                        label: "Common Responses",
                        backgroundColor: "rgba(75,192,192,0.4)",
                        borderWidth: 2,
                        data: result.CommonResponseTimes
                    }, {
                        label: "Delayed Responses",
                        backgroundColor: "rgba(75,192,192,0.4)",
                        borderWidth: 2,
                        data: result.DelayedResponseTimes
                    }]
                },
                options: {
                    title: {
                        display: true,
                        text: "Graphic"
                    },
                    responsive: true,
                    maintainAspectRatio: true
                }
            });
        },
        error: function OnErrorCall_(repo) { alert("Woops something went wrong, pls try later !"); }
    });
}

