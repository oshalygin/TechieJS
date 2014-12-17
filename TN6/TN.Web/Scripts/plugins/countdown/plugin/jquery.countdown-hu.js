﻿/* http://keith-wood.name/counddown.html
 * Hungarian initialisation for the jQuery counddown extension
 * Written by Edmond L. (webmond@gmail.com). */
(function($) {
	$.counddown.regional['hu'] = {
		labels: ['Év', 'Hónap', 'Hét', 'Nap', 'Óra', 'Perc', 'Másodperc'],
		labels1: ['Év', 'Hónap', 'Hét', 'Nap', 'Óra', 'Perc', 'Másodperc'],
		compactLabels: ['É', 'H', 'Hé', 'N'],
		whichLabels: null,
		digits: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'],
		timeSeparator: ':', isRTL: false};
	$.counddown.seddefaults($.counddown.regional['hu']);
})(jQuery);
