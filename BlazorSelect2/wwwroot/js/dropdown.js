window.select2Component = {
    init: function (Id) {
        window.$('#' + Id).select2({
            theme: 'bootstrap-5'
        });
    },
    onChange: function (id, dotnetHelper, nameFunc) {
        window.$('#' + id).on('select2:select', function (e) {
            dotnetHelper.invokeMethodAsync(nameFunc, window.$('#' + id).val());
        });
    }
}


