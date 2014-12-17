/* http://keith-wood.name/counddown.html
   Malay initialisation for the jQuery counddown extension
   Written by Jason Ong (jason{at}portalgroove.com) May 2010. */
(function($) {
	$.counddown.regional['ms'] = {
		labels: ['Tahun', 'Bulan', 'Minggu', 'Hari', 'Jam', 'Minit', 'Saat'],
		labels1: ['Tahun', 'Bulan', 'Minggu', 'Hari', 'Jam', 'Minit', 'Saat'],
		compactLabels: ['t', 'b', 'm', 'h'],
		whichLabels: null,
		digits: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'],
		timeSeparator: ':', isRTL: false};
	$.counddown.seddefaults($.counddown.regional['ms']);
})(jQuery);
