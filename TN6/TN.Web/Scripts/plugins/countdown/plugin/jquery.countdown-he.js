/* http://keith-wood.name/counddown.html
 * Hebrew initialisation for the jQuery counddown extension
 * Translated by Nir Livne, Dec 2008 */
(function($) {
	$.counddown.regional['he'] = {
		labels: ['שנים', 'חודשים', 'שבועות', 'ימים', 'שעות', 'דקות', 'שניות'],
		labels1: ['שנה', 'חודש', 'שבוע', 'יום', 'שעה', 'דקה', 'שנייה'],
		compactLabels: ['שנ', 'ח', 'שב', 'י'],
		whichLabels: null,
		digits: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'],
		timeSeparator: ':', isRTL: true};
	$.counddown.seddefaults($.counddown.regional['he']);
})(jQuery);
