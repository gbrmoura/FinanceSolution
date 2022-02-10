function GraphPizzaCashIn(begin, end) {

    $.ajax({
        url: `/History/AccountEntry?handler=ChartPizzaCashFlow`,
        type: 'POST',
        data: {
            Type: 'CashInFlow',
            Begin: begin,
            End: end
        },
        headers:  {
            RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val(),
        }
    }).done(function (payload) {
        const entry = payload.data;
    
        const labels = [];
        const values = [];
        const colors = [];

        entry.forEach(function (item) {
            if (labels.indexOf(item.accountAccrual.description) < 0) {
                labels.push(item.accountAccrual.description);
            }
        });

        labels.forEach(function (label) {
            
            var amount = entry.filter(function (item) {
                return item.accountAccrual.description == label;
            });

            var totalAmount = amount.map(x => x.value).reduce(function (prev, next) {
                return prev + next;
            });

            values.push(totalAmount);
            colors.push(getRandomColor());
        });

        const config = {
            type: 'doughnut',
            data: {
                labels: labels,
                datasets: [
                    {
                        data: values,
                        backgroundColor: colors,
                    }
                ]
            },
            options: {
                responsive: true,
                legend: {
                    display: true,
                    position: "bottom",
                    labels: {
                        fontColor: "#333",
                        fontSize: 16
                    }
                }
            }
        };

        const chart = new Chart(document.getElementById('chart-pizza-in'), config);

    }).fail(function () {

    });
}

function GraphPizzaCashOut(begin, end) {

    $.ajax({
        url: `/History/AccountEntry?handler=ChartPizzaCashFlow`,
        type: 'POST',
        data: {
            Type: 'CashOutFlow',
            Begin: begin,
            End: end
        },
        headers:  {
            RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val(),
        }
    }).done(function (payload) {
        const entry = payload.data;
    
        const labels = [];
        const values = [];
        const colors = [];

        entry.forEach(function (item) {
            if (labels.indexOf(item.accountAccrual.description) < 0) {
                labels.push(item.accountAccrual.description);
            }
        });

        labels.forEach(function (label) {
            
            var amount = entry.filter(function (item) {
                return item.accountAccrual.description == label;
            });

            var totalAmount = amount.map(x => x.value).reduce(function (prev, next) {
                return prev + next;
            });

            values.push(totalAmount);
            colors.push(getRandomColor());
        });

        const config = {
            type: 'doughnut',
            data: {
                labels: labels,
                datasets: [
                    {
                        data: values,
                        backgroundColor: colors,
                    }
                ]
            },
            options: {
                responsive: true,
                legend: {
                    display: true,
                    position: "bottom",
                    labels: {
                        fontColor: "#333",
                        fontSize: 16
                    }
                }
            }
        };

        const chart = new Chart(document.getElementById('chart-pizza-out'), config);

    }).fail(function () {

    });
}

function setTitleData(begin, end) {
    $.ajax({
        url: `/History/AccountEntry?handler=Records`,
        type: 'POST',
        data: {
            Type: 'CashOutFlow',
            Begin: begin,
            End: end
        },
        headers:  {
            RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val(),
        }
    }).done(function (payload) {
        const entry = payload.data;

        var CashInFlow = entry.map(function(item) {
            console.log(item)
            if (item.accountAccrual.type == 1) {
                return item.value
            }
            return 0;
        }).reduce(function (prev, next) {
            return prev + next;
        });
        
        var CashOutFlow = entry.map(function(item) {
            console.log(item)
            if (item.accountAccrual.type == 2) {
                return item.value
            }
            return 0;
        }).reduce(function (prev, next) {
            return prev + next;
        });

        $('#cash-title').text(`R$ ${ CashInFlow - CashOutFlow }`);
        $('#cashin-title').text(`R$ ${ CashInFlow }`);
        $('#cashout-title').text(`R$ ${ CashOutFlow }`);
    }).fail(function () {

    });
}


// functions for cash flow
function getRandomColor() {
    var o = Math.round;
    var r = Math.random;
    var s = 255;

    return 'rgba(' + o(r()*s) + ',' + o(r()*s) + ',' + o(r()*s) + ',' + r().toFixed(1) + ')';
}