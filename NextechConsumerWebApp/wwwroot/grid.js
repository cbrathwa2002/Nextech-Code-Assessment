var customStore = new DevExpress.data.CustomStore({
    load: function (loadOptions) {
        var d = $.Deferred();
        $.getJSON('http://localhost:63184/api/news').done(function (data) {
            d.resolve(data, { totalCount: data.length });
        });
        return d.promise();
    }
});

var gridDataSourceConfiguration = {
    store: customStore
};

$(function () {
    $("#gridContainer").dxDataGrid({dataSource: gridDataSourceConfiguration,columns: [
            'author',
        {
            dataField: 'title',
            width:  200
            }
    ],
   
        sorting: 'multiple',
        filterRow: { visible: true } ,
        allowColumnReordering: true,
        allowColumnResizing: true
    });
});
