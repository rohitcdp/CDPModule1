
////Data
//var data = [{
//    "id": 1,
//    "title": "iPhone 9",
//    "sale": 549

//},
//{
//    "id": 2,
//    "title": "iPhone XR",
//    "sale": 1490

//},
//{
//    "id": 3,
//    "title": "iPhone 11",
//    "sale": 140

//},
//{
//    "id": 4,
//    "title": "iPhone 11 pro",
//    "sale": 812

//}
//]


//var str = JSON.stringify(data);
//console.log(data);

//const label = [];
//const series = [];

//for (var k in data) {
//    label.push(data[k].title);
//    series.push(data[k].sale);

//}

//console.log(label);


////Pie Chart

//var PieOptions = {
//    series: series,
//    chart: {
//        width: 380,
//        type: 'pie',
//    },
//    labels: label,
//    responsive: [{
//        breakpoint: 480,
//        options: {
//            chart: {
//                width: 200
//            },
//            legend: {
//                position: 'bottom'
//            }
//        }
//    }]
//};

////var PieChart = new ApexCharts(document.querySelector(".PieChart"), PieOptions);
////PieChart.render();


////chart 2

//var BarOptions = {
//    series: [{
//        data: series
//    }],
//    chart: {
//        type: 'bar',
//        height: 380
//    },
//    plotOptions: {
//        bar: {
//            barHeight: '100%',
//            distributed: true,
//            horizontal: true,
//            dataLabels: {
//                position: 'bottom'
//            },
//        }
//    },
//    colors: ['#33b2df', '#546E7A', '#d4526e'],
//    dataLabels: {
//        enabled: true,
//        textAnchor: 'start',
//        style: {
//            colors: ['#fff']
//        },
//        formatter: function (val, opt) {
//            return opt.w.globals.labels[opt.dataPointIndex] + ":  " + val
//        },
//        offsetX: 0,
//        dropShadow: {
//            enabled: true
//        }
//    },
//    stroke: {
//        width: 1,
//        colors: ['#fff']
//    },
//    xaxis: {
//        categories: label,
//    },
//    yaxis: {
//        labels: {
//            show: false
//        }
//    },
//    title: {
//        text: 'Custom DataLabels',
//        align: 'center',
//        floating: true
//    },
//    subtitle: {
//        text: 'Category Names as DataLabels inside bars',
//        align: 'center',
//    },
//    tooltip: {
//        theme: 'dark',
//        x: {
//            show: false
//        },
//        y: {
//            title: {
//                formatter: function () {
//                    return ''
//                }
//            }
//        }
//    }
//};

////var BarChart = new ApexCharts(document.querySelector(".BarChart"), BarOptions);
////BarChart.render();

//getChart("PieChart");

////function
//function getChart(ChartType) {
//    alert(ChartType);
//    //document.getElementById('chartDiv').className = ChartType;

//    if (ChartType =="PieChart") {
//        var Chart=new ApexCharts(document.querySelector("#chartDiv"), PieOptions);
//        Chart.render();
//    }

//    if (ChartType =="BarChart") {
//        var Chart=new ApexCharts(document.querySelector("#chartDiv"), BarOptions);
//        Chart.render();
//    }

//}

