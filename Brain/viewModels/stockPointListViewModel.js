(function($) {
	brain.stockPointListViewModel = vm = new kendo.data.ObservableObject({
		
		onStockPointListInit: function (e) {
			
		},
		onStockPointListViewShow: function (e) {
			///<summary>Init event for the stock point list view. It is called exactly once</summary>
			// check if online or offline mode
			if (brain.hasNetworkConnection() === 'true') {
				// execute in online mode

				var url = '/dummydata/stockpoint-list-view.json';
				var dat = [
					{ 'stockPointId': '1', 'stockPointName': 'Vernal, UT', 'toolQty': '33' },
					{ 'stockPointId': '2', 'stockPointName': 'Williston, ND', 'toolQty': '56' },
					{ 'stockPointId': '3', 'stockPointName': 'Fort Collins, CO', 'toolQty': '15' }
				];

				//var dataSource = new kendo.data.DataSource({
				//	type: 'json',
				//	transport: {
				//		read: url,
				//		dataType: 'json'
				//	}

				//});

				var dataSource = new kendo.data.DataSource({
					data: dat
				});

				var $stockPointListItems = $('#stockPointListItems');
				if ($stockPointListItems.data('kendoMobileListView')) {
					// redraw the list view if needed.
					$stockPointListItems.data('kendoMobileListView').refresh();
				} else {
					$stockPointListItems.kendoMobileListView({
						//headerTemplate: $('#reports-header-template').text(),
						fixedHeaders: true,
						template: $('#stockpoint-list-item-template').html(),
						dataSource: dataSource,
						//filterable: {
						//	field: 'reportName',
						//	operator: 'contains'
						//},
						click: function (e) {
							var stockPointId = e.dataItem.stockPointId;
							brain.app.navigate('./views/toolList.html?id' + stockPointId, 'slide:left');
						}
					});
				}
			} else {
				// exectute in offline mode
			}
		}
	});
})(jQuery)