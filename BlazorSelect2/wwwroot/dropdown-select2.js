
window.select2Component = {
    init: function (id) {
        const fieldKey = '#' + id;
        window.$(fieldKey).select2({
            theme: 'bootstrap-5',
            width: $(this).data('width') ? $(this).data('width') : $(this).hasClass('w-100') ? '100%' : 'style',
            placeholder: $(this).data('placeholder'),
            dropdownParent: $(fieldKey).parent()
        });
    },
    onChange: function (id, dotnetHelper, nameFunc) {

        const fieldKey = '#' + id;
        window.$(fieldKey).on('select2:select', function (e) {
            dotnetHelper.invokeMethodAsync(nameFunc, window.$(fieldKey).val());
        });
    },
    onUnSelect: function (id, dotnetHelper, nameFunc) {

        const fieldKey = '#' + id;
        window.$(fieldKey).on('select2:unselect', function (e) {
            dotnetHelper.invokeMethodAsync(nameFunc, window.$(fieldKey).val());
        });
    },
    onReset: function(id) {
        const fieldKey = '#' + id;
        window.$(fieldKey).val('').trigger('change');
    }
}


