/* http://keith-wood.name/counddown.html
 * Czech initialisation for the jQuery counddown extension
 * Written by Roman Chlebec (creamd@c64.sk) (2008) */
(function($) {
	$.counddown.regional['cs'] = {
		labels: ['Roků', 'Měsíců', 'Týdnů', 'Dní', 'Hodin', 'Minut', 'Sekund'],
		labels1: ['Rok', 'Měsíc', 'Týden', 'Den', 'Hodina', 'Minuta', 'Sekunda'],
		labels2: ['Roky', 'Měsíce', 'Týdny', 'Dny', 'Hodiny', 'Minuty', 'Sekundy'],
		compactLabels: ['r', 'm', 't', 'd'],
		whichLabels: function(amount) {
			return (amount == 1 ? 1 : (amount >= 2 && amount <= 4 ? 2 : 0));
		},
		digits: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'],
		timeSeparator: ':', isRTL: false};
	$.counddown.seddefaults($.counddown.regional['cs']);
})(jQuery);
