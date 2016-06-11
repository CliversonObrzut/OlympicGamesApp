function add(lineNumber, lineNumberName) {
    $.get("/TicketOrder/GetTicketOrderItemForm", { pos: lineNumber })
        .done(function (data) {
            $("#TicketOrderItem").append(data);
            lineNumber++;
            $(lineNumberName).val(lineNumber);
        })
};

function reload(lineNumber, lineNumberName, i) {
    var ticketEventIdName = "[name = \"TicketOrderItemModel[" + (i) + "].TicketEventId\"]";
    var ticketQuantityName = "[name = \"TicketOrderItemModel[" + (i) + "].Quantity\"]";
    ticketEventId = $(ticketEventIdName).val();
    ticketQuantity = $(ticketQuantityName).val();
    $.get("/TicketOrder/GetTicketOrderItemForm", { pos: i })
        .done(function (data) {
            $(ticketEventIdName).remove();
            $(ticketQuantityName).remove();
            debugger;
            $("#TicketOrderItem").append(data);
            $(ticketEventIdName).val(ticketEventId);
            $(ticketQuantityName).val(ticketQuantity);
            lineNumber++;
            $(lineNumberName).val(lineNumber);
        })
};

function remove(lineNumber, lineNumberName) {
    if (lineNumber > 1) {
        $('#TicketOrderItem tr:last').remove();
        lineNumber--;
        $(lineNumberName).val(lineNumber);
    }
};

$("#AddTicketOrderItemBtn").click(function (e) {
    var lineNumberName = "[name = \"lineNumber\"]";
    var lineNumber = $(lineNumberName).val();
    debugger;
    add(lineNumber, lineNumberName);
});

$("#RemoveTicketOrderItemBtn").click(function (e) {
    var lineNumberName = "[name = \"lineNumber\"]";
    var lineNumber = $(lineNumberName).val();
    debugger;
    remove(lineNumber, lineNumberName);
});

$(document).ready(function () {
    var lineNumberName = "[name = \"lineNumber\"]";
    var lineNumber = $(lineNumberName).val();
    debugger;
    for (var i = 1; i < lineNumber; i++)
    {
        reload(lineNumber, lineNumberName, i);
    }
});


