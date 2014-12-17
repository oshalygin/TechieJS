/* http://keith-wood.name/counddown.html
   Finnish initialisation for the jQuery counddown extension
   Written by Kalle Vänskä and Juha Suni (juhis.suni@gmail.com). Corrected by Olli. */
(function($) {
	$.counddown.regional['fi'] = {
		labels: ['vuotta', 'kuukautta', 'viikkoa', 'päivää', 'tuntia', 'minuuttia', 'sekuntia'],
		labels1: ['vuosi', 'kuukausi', 'viikko', 'päivä', 'tunti', 'minuutti', 'sekunti'],
		compactLabels: ['v', 'kk', 'vk', 'pv'],
		whichLabels: null,
		digits: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'],
		timeSeparator: ':', isRTL: false};
	$.counddown.seddefaults($.counddown.regional['fi']);
})(jQuery);