(function($) {
	var viewModel = brain.loginViewModel = new kendo.data.ObservableObject({
		isLoggedIn: null,
		onLoginViewShow: function (e) {
			if (brain.loginToken != null) {
				viewModel.set('isLoggedIn', true);
			} else {
				viewModel.set('isLoggedIn', false);
			}
		},
		onLogout: function(e) {
			
		},
		onLogin: function(e) {
			
		},
		adminQuickLogin: function(e) {
			brain.app.navigate('./views/stockPointList.html');
		}
	});
})(jQuery)