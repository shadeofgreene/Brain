(function ($) {
	brain.toolListViewModel = vm = new kendo.data.ObservableObject({

		onToolListViewInit: function (e) {
			///<summary>Init event for the stock point list view. It is called exactly once</summary>
			// check if online or offline mode
			if (brain.hasNetworkConnection() === 'true') {
				// execute in online mode

				var url = '';
				var dat = [
					{ 'toolId': '1', 'toolSerialNumber': '16546543898370', 'toolStatus': 'Ground', 'statusHexColor': '#009E07', 'toolThread': 'XT', 'toolSizeWhole': '6', 'toolSizeFraction': '1/32', 'toolDriftWhole': '6', 'toolDriftFraction': '1/16' },
					{ 'toolId': '2', 'toolSerialNumber': '16543443898314', 'toolStatus': 'Ground', 'statusHexColor': '#009E07', 'toolThread': 'XT', 'toolSizeWhole': '6', 'toolSizeFraction': '1/32', 'toolDriftWhole': '6', 'toolDriftFraction': '1/16' },
					{ 'toolId': '3', 'toolSerialNumber': '16546528498364', 'toolStatus': 'Ground', 'statusHexColor': '#009E07', 'toolThread': 'XT', 'toolSizeWhole': '6', 'toolSizeFraction': '1/32', 'toolDriftWhole': '6', 'toolDriftFraction': '1/16' },
					{ 'toolId': '4', 'toolSerialNumber': '16545609898374', 'toolStatus': 'Ground', 'statusHexColor': '#009E07', 'toolThread': 'XT', 'toolSizeWhole': '6', 'toolSizeFraction': '1/32', 'toolDriftWhole': '6', 'toolDriftFraction': '1/16' },
					{ 'toolId': '5', 'toolSerialNumber': '16525092898389', 'toolStatus': 'Ground', 'statusHexColor': '#009E07', 'toolThread': 'XT', 'toolSizeWhole': '6', 'toolSizeFraction': '1/32', 'toolDriftWhole': '6', 'toolDriftFraction': '1/16' },
					{ 'toolId': '6', 'toolSerialNumber': '16546543898345', 'toolStatus': 'Ground', 'statusHexColor': '#009E07', 'toolThread': 'XT', 'toolSizeWhole': '6', 'toolSizeFraction': '1/32', 'toolDriftWhole': '6', 'toolDriftFraction': '1/16' },
					{ 'toolId': '7', 'toolSerialNumber': '16546543834591', 'toolStatus': 'Ground', 'statusHexColor': '#009E07', 'toolThread': 'XT', 'toolSizeWhole': '6', 'toolSizeFraction': '1/32', 'toolDriftWhole': '6', 'toolDriftFraction': '1/16' },
					{ 'toolId': '8', 'toolSerialNumber': '16546543856014', 'toolStatus': 'Ground', 'statusHexColor': '#009E07', 'toolThread': 'XT', 'toolSizeWhole': '6', 'toolSizeFraction': '1/32', 'toolDriftWhole': '6', 'toolDriftFraction': '1/16' },
					{ 'toolId': '9', 'toolSerialNumber': '16546543898374', 'toolStatus': 'Ground', 'statusHexColor': '#009E07', 'toolThread': 'XT', 'toolSizeWhole': '6', 'toolSizeFraction': '1/32', 'toolDriftWhole': '6', 'toolDriftFraction': '1/16' },
					{ 'toolId': '10', 'toolSerialNumber': '16546543898374', 'toolStatus': 'Ground', 'statusHexColor': '#009E07', 'toolThread': 'XT', 'toolSizeWhole': '6', 'toolSizeFraction': '1/32', 'toolDriftWhole': '6', 'toolDriftFraction': '1/16' },
					{ 'toolId': '11', 'toolSerialNumber': '16546543898374', 'toolStatus': 'Ground', 'statusHexColor': '#009E07', 'toolThread': 'XT', 'toolSizeWhole': '6', 'toolSizeFraction': '1/32', 'toolDriftWhole': '6', 'toolDriftFraction': '1/16' },
					{ 'toolId': '12', 'toolSerialNumber': '16546543898374', 'toolStatus': 'Ground', 'statusHexColor': '#009E07', 'toolThread': 'XT', 'toolSizeWhole': '6', 'toolSizeFraction': '1/32', 'toolDriftWhole': '6', 'toolDriftFraction': '1/16' },
					{ 'toolId': '13', 'toolSerialNumber': '16546543898374', 'toolStatus': 'Ground', 'statusHexColor': '#009E07', 'toolThread': 'XT', 'toolSizeWhole': '6', 'toolSizeFraction': '1/32', 'toolDriftWhole': '6', 'toolDriftFraction': '1/16' },
					{ 'toolId': '14', 'toolSerialNumber': '16546543898374', 'toolStatus': 'Ground', 'statusHexColor': '#009E07', 'toolThread': 'XT', 'toolSizeWhole': '6', 'toolSizeFraction': '1/32', 'toolDriftWhole': '6', 'toolDriftFraction': '1/16' }
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

				var $toolListItems = $('#toolListItems');
				if ($toolListItems.data('kendoMobileListView')) {
					// redraw the list view if needed.
					$toolListItems.data('kendoMobileListView').refresh();
				} else {
					$toolListItems.kendoMobileListView({
						//headerTemplate: $('#reports-header-template').text(),
						fixedHeaders: true,
						template: $('#tool-list-item-template').html(),
						dataSource: dataSource,
						//filterable: {
						//	field: 'reportName',
						//	operator: 'contains'
						//},
						click: function (e) {
							//navigate to tool details
							
						}
					});
				}
			} else {
				// exectute in offline mode
			}
		},
		onToolListViewShow: function (e) {
			///<summary>Show event for the stock point list view. It is called everytime the view is loaded</summary>
			// check if online or offline mode
			if (brain.hasNetworkConnection() === 'true') {
				// execute in online mode
			} else {
				// exectute in offline mode
			}
		}
	});
})(jQuery)