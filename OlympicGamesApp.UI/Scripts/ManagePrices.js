function a(i) {
    var ticketEventIdName = "[name = \"TicketOrderItemModel[" + (i) + "].TicketEventId\"]";
    var ticketUnitItemPriceName = "[name = \"TicketOrderItemModel[" + (i) + "].UnitItemPrice\"]";
    var ticketQuantityName = "[name = \"TicketOrderItemModel[" + (i) + "].Quantity\"]";
    var ticketTotalItemPriceName = "[name = \"TicketOrderItemModel[" + (i) + "].TotalItemPrice\"]";
    var ticketEventId = $(ticketEventIdName).val();
    if (ticketEventId == "") {
        $(ticketUnitItemPriceName).val("");
        $(ticketQuantityName).val("");
        $(ticketTotalItemPriceName).val("");
        c();
        b(i);
    }
    else {
        $.get("/TicketOrder/GetTicketUnitPrice", { ticketId: ticketEventId })
            .done(function (data1) {
                $(ticketUnitItemPriceName).val(data1);
                b(i);
            });
    }
};

function b(i) {
    var rowsNumber2 = $("#TicketOrderItem > tr").length;
    debugger;
    var ticketEventId = 0;
    var ticketQuantity = 0;
    var ticketEventIdName = "[name = \"TicketOrderItemModel[" + (i) + "].TicketEventId\"]";
    var ticketQuantityName = "[name = \"TicketOrderItemModel[" + (i) + "].Quantity\"]";
    var ticketTotalItemPriceName = "[name = \"TicketOrderItemModel[" + (i) + "].TotalItemPrice\"]";
    ticketEventId = $(ticketEventIdName).val();
    ticketQuantity = $(ticketQuantityName).val();
    if (ticketQuantity >= 1 && ticketQuantity <= 10 && ticketEventId != "") {
        $.get("/TicketOrder/GetTicketTotalPrice", { ticketId: ticketEventId, quantity: ticketQuantity })
             .done(function (data2) {
                 $(ticketTotalItemPriceName).val(data2);
                 i++;
                 if (i == rowsNumber2) {
                     c();
                 }
                 else {
                     c();
                     a(i);
                 }
             });
    }
    else {
        $(ticketTotalItemPriceName).val("");
        i++;
        if (i == rowsNumber2) {
            c();
        }
        else {
            c();
            a(i);
        }
    }
};

function c() {
    var rowsNumber3 = $("#TicketOrderItem > tr").length;
    var totalCostName = "[name = \"TotalCost\"]";
    var totalCostDouble = 0;
    for (var k = 0; k < rowsNumber3; k++) {
        var ticketTotalItemPriceName = "[name = \"TicketOrderItemModel[" + (k) + "].TotalItemPrice\"]";
        var ticketTotalItemPrice = $(ticketTotalItemPriceName).val();
        var number = 0;
        number = Number(ticketTotalItemPrice.replace(/[^0-9\.-]+/g, ""));
        if (number < 10) {
            number = number * 1000;
        }
        else {
            number = number / 100;
        }
        totalCostDouble = totalCostDouble + number;
        debugger;
    }
    totalCostDouble = totalCostDouble.toFixed(2);
    var totalCostAsString = "R$ " + totalCostDouble;
    $(totalCostName).val(totalCostAsString);
};

$(document.body).on('change', function () {
    var i = 0;
    debugger;
    a(i);
});

$(document).ready(function () {
    var i = 0;
    debugger;   
    a(i);
});




