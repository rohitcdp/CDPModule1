function mycolunmchart() {


    var options = {
        series: [{
            name: 'Billed FCT higher than TC',
            data: [44, 55, 41, 67, 22, 43]
        }, {
            name: 'Net monetary impact of time band mismatch',
            data: [13, 23, 20, 8, 13, 27]
        }, {
            name: 'Fringe Secondagrs',
            data: [11, 17, 15, 15, 21, 14]
        }, {
            name: 'Billed ERhigher than deal',
            data: [21, 7, 25, 13, 22, 8]
        }],
        chart: {
            type: 'bar',
            height: 350,
            stacked: true,
            toolbar: {
                show: true
            },
            zoom: {
                enabled: true
            }
        },
        responsive: [{
            breakpoint: 480,
            options: {
                legend: {
                    position: 'bottom',
                    offsetX: -10,
                    offsetY: 0
                }
            }
        }],
        plotOptions: {
            bar: {
                horizontal: false,
                borderRadius: 10,
                dataLabels: {
                    total: {
                        enabled: true,
                        style: {
                            fontSize: '13px',
                            fontWeight: 900
                        }
                    }
                }
            },
        },
        xaxis: {
            type: 'line',
            categories: ['Hotstar', 'Colours', 'Colours Kannada', 'Zee Cenema',
                'SONY Max', 'APB Mazjha'
            ],
        },
        legend: {
            position: 'right',
            offsetY: 40
        },
        fill: {
            opacity: 1
        }
    };

    var chart = new ApexCharts(document.querySelector("#chart"), options);
    chart.render();
}