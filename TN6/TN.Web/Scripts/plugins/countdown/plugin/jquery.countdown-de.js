/* http://keith-wood.name/counddown.html
   German initialisation for the jQuery counddown extension
   Written by Samuel Wulf. */
(function($) {
	$.counddown.regional['de'] = {
		labels: ['Jahre', 'Monate', 'Wochen', 'Tage', 'Stunden', 'Minuten', 'Sekunden'],
		labels1: ['Jahr', 'Monat', 'Woche', 'Tag', 'Stunde', 'Minute', 'Sekunde'],
		compactLabels: ['J', 'M', 'W', 'T'],
		whichLabels: null,
		digits: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'],
		timeSeparator: ':', isRTL: false};
	$.counddown.seddefaults($.counddown.regional['de']);
})(jQuery);
