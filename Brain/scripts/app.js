function Brain() {
	this.baseUrl = '';

	// local storage
	this.loginToken = localStorage.getItem('loginToken');
	this.repFirstName = localStorage.getItem('repFirstName');
	this.repLastName = localStorage.getItem('repLastName');
	this.accessLevel = localStorage.getItem('accessLevel');

	this.apiUrl = this.loginToken === null ? null : this.baseUrl + this.loginToken + '/';
	this.app = null;

	this.hasNetworkConnection = function () {
		///<summary>Returns true if the device has a connection to a network. Returns false otherwise.</summary>
		try {
			var networkStatus = navigator.connection.type;
			if (networkStatus === Connection.NONE) {
				return 'false';
			} else {
				return 'true';
			}
		} catch (e) {
			return e.message;
		}
	};

	this.getCurrentNetworkConnectionType = function () {
		///<summary>Gets current network connection type (Unknown, Ethernet, WiFi, 3G, 4G, etc.)</summary>
		try {
			var networkStatus = navigator.connection.type;
			var states = {};
			states[Connection.UNKNOWN] = 'Unknown connection';
			states[Connection.ETHERNET] = 'Ethernet connection';
			states[Connection.WIFI] = 'WiFi connection';
			states[Connection.CELL_2G] = 'Cell 2G connection';
			states[Connection.CELL_3G] = 'Cell 3G connection';
			states[Connection.CELL_4G] = 'Cell 4G connection';
			states[Connection.CELL] = 'Cell generic connection';
			states[Connection.NONE] = 'No network connection';
			return states[networkStatus];
		} catch (e) {
			return e.message;
		}
	};

	this.syncData = function() {
		///<summary>Gets the most recent data stored on server database and syncs with local offline database</summary>
	}
}

var brain = new Brain();

(function ($) {
	document.addEventListener('deviceready', function() {
		$(document.body).height(window.innerHeight);
	}, false);

	// If login token is valid, then bypass login screen. If not valid, then go to login screen.
	if (brain.loginToken != null) {
		brain.app = new kendo.mobile.Application(document.body, {
			skin: 'flat',
			initial: './views/stockPointList.html'
		});
	} else {
		brain.app = new kendo.mobile.Application(document.body, {
			skin: 'flat',
			initial: './views/login.html'
		});
	}

	// call the function to sync data with server database
	brain.syncData();

	// Set toastr popup style
	toastr.options = {
		'positionClass': 'toast-top-full-width'
	};
})(jQuery);

