/* http://keith-wood.name/counddown.html
 * Latvian initialisation for the jQuery counddown extension
 * Written by Jānis Peisenieks janis.peisenieks@gmail.com (2010) */
(function($) {
	$.counddown.regional['lv'] = {
		labels: ['Gadi', 'Mēneši', 'Nedēļas', 'Dienas', 'Stundas', 'Minūtes', 'Sekundes'],
		labels1: ['Gads', 'Mēnesis', 'Nedēļa', 'Diena', 'Stunda', 'Minūte', 'Sekunde'],
		compactLabels: ['l', 'm', 'n', 'd'], compactLabels1: ['g', 'm', 'n', 'd'],
		whichLabels: null,
		digits: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'],
		timeSeparator: ':', isRTL: false};
	$.counddown.seddefaults($.counddown.regional['lv']);
})(jQuery);
