(function () {
    $(document).ready(function() {
        var source = $("#state-option-template").html();
        var template = Handlebars.compile(source);
        
        $("#country").change(function (event) {
            var countrySelected = this.value;
            console.log("The user selected the country value" + countrySelected);

            $.get('/Customer/States', {country: countrySelected},
                function (data, textStatus, jqXHR) {
                    debugger;
                    console.log("The success handler for the get was called")
                    var context = {state: data}
                }
        });
    });
})();