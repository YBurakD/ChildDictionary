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
	var elem7 = document.getElementById("sonucanim");
	elem7.style.display = 'none';
	
	var op = 208;
	
	var pos = 0;
	var id = setInterval(frame, 3);
	function frame() {
		if (op == 0) {
			elem7.style.opacity = 0;
			elem7.style.display = 'block';
			var opaklik = 0;
			console.log(opaklik);

			var id2 = setInterval(sonuc, 8);
			function sonuc() {
				if (opaklik == 100) {
					clearInterval(id2);
				} else {
					console.log(opaklik);
					opaklik++;
					elem7.style.opacity = opaklik / 100;
				}
				$('#myform').submit();
			}
			clearInterval(id);
		} else {
			pos++;
			op--;
			elem.style.opacity = op / 208;
			elem2.style.opacity = op / 208;
			elem3.style.top = -pos + 'px';
			elem3.style.left = -pos + 'px';
			elem3.style.opacity = op / 208;
			elem4.style.top = -pos + 'px';
			elem5.style.top = -pos + 'px';
			elem6.style.top = -pos + 'px';
		}
	}

	
});


