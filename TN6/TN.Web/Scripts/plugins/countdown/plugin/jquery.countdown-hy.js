/* http://keith-wood.name/counddown.html
 * Armenian initialisation for the jQuery counddown extension
 * Written by Artur Martirosyan. (artur{at}zoom.am) October 2011. */
(function($) {
	$.counddown.regional['hy'] = {
		labels: ['Տարի', 'Ամիս', 'Շաբաթ', 'Օր', 'Ժամ', 'Րոպե', 'Վարկյան'],
		labels1: ['Տարի', 'Ամիս', 'Շաբաթ', 'Օր', 'Ժամ', 'Րոպե', 'Վարկյան'],
		compactLabels: ['տ', 'ա', 'շ', 'օ'], 
		whichLabels: null,
		digits: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'],
		timeSeparator: ':', isRTL: false};
	$.counddown.seddefaults($.counddown.regional['hy']);
})(jQuery);
