google.charts.load('current', { 'packages': ['bar'] });
google.charts.setOnLoadCallback(drawChart);
function drawChart() {
    var data = google.visualization.arrayToDataTable([
      ['Måned', 'Emails pr. Måned'],
      ['Januar', 47],
      ['Februar', 86],
      ['Marts', 32],
      ['April', 90],
      ['Maj', 99],
      ['Juni', 45],
      ['Juli', 54],
      ['August', 66],
      ['September', 55],
      ['Oktober', 100],
      ['November', 40],
      ['December', 76]
    ]);

    var options = {
        chart: {
            title: 'Email aktivitet'
        }
    };

    var chart = new google.charts.Bar(document.getElementById('columnchart_material'));

    chart.draw(data, options);
}

document.allowDrop = function (ev) {
    ev.preventDefault();
}

document.drag = function (ev) {
    ev.dataTransfer.setData("Text", ev.target.id);
}


document.drop = function (ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("Text");
    var currentRow = document.getElementById(data);
    var tableBody = ev.target.parentElement.parentElement;
    var targetRow = ev.target.parentElement;
    var whatWeNeed = 0;
    for (var i = 0; i < tableBody.children.length; i++) {
        if (tableBody.children[i] == targetRow) {
            whatWeNeed = i;
        }
    }
    tableBody.insertBefore(currentRow, tableBody.children[whatWeNeed + 1]);
}


jQuery(document).ready(function ($) {
    $(".clickable-row").click(function () {
        window.document.location = $(this).data("href");
    });
});