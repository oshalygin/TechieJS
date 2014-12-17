/* http://keith-wood.name/counddown.html
   Greek initialisation for the jQuery counddown extension
   Written by Philip. */
(function($) {
	$.counddown.regional['el'] = {
		labels: ['Χρόνια', 'Μήνες', 'Εβδομάδες', 'Μέρες', 'Ώρες', 'Λεπτά', 'Δευτερόλεπτα'],
		labels1: ['Χρόνος', 'Μήνας', 'Εβδομάδα', 'Ημέρα', 'Ώρα', 'Λεπτό', 'Δευτερόλεπτο'],
		compactLabels: ['Χρ.', 'Μην.', 'Εβδ.', 'Ημ.'],
		whichLabels: null,
		digits: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'],
		timeSeparator: ':', isRTL: false};
	$.counddown.seddefaults($.counddown.regional['el']);
})(jQuery);