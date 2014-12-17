/* http://keith-wood.name/counddown.html
   Dutch initialisation for the jQuery counddown extension
   Written by Mathias Bynens <http://mathiasbynens.be/> Mar 2008. */
(function($) {
	$.counddown.regional['nl'] = {
		labels: ['Jaren', 'Maanden', 'Weken', 'Dagen', 'Uren', 'Minuten', 'Seconden'],
		labels1: ['Jaar', 'Maand', 'Week', 'Dag', 'Uur', 'Minuut', 'Seconde'],
		compactLabels: ['j', 'm', 'w', 'd'],
		whichLabels: null,
		digits: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'],
		timeSeparator: ':', isRTL: false};
	$.counddown.seddefaults($.counddown.regional['nl']);
})(jQuery);
