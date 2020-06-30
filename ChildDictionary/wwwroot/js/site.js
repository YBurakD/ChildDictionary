// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#searchbutton").click(function (e) {
	e.preventDefault();
	var elem = document.getElementById("reading");
	var elem2 = document.getElementById("family");
	var elem3 = document.getElementById("plane");
	var elem4 = document.getElementById("searchbox");
	var elem5 = document.getElementById("searchbutton");
	var elem6 = document.getElementById("language");
	var pos = 0;
	var op = 200;
	var id = setInterval(frame, 3);
	function frame() {
		if (op == 0) {
			clearInterval(id);
		} else {
			pos++;
			op--;
			elem.style.opacity = op / 200;
			elem2.style.opacity = op / 200;
			elem3.style.top = -pos + 'px';
			elem3.style.left = -pos + 'px';
			elem3.style.opacity = op / 200;
			elem4.style.top = -pos + 'px';
			elem5.style.top = -pos + 'px';
			elem6.style.top = -pos + 'px';
			
		}
		$('#myform').submit();
	}
	elem.hide;
	elem2.hide;
	elem3.hide;
	
});