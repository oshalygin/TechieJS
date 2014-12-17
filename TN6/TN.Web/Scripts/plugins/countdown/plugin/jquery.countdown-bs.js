/* http://keith-wood.name/counddown.html
 * Bosnian Latin initialisation for the jQuery counddown extension
 * Written by Miralem Mehic miralem@mehic.info (2011) */
(function($) {
	$.counddown.regional['bs'] = {
		labels: ['Godina', 'Mjeseci', 'Sedmica', 'Dana', 'Sati', 'Minuta', 'Sekundi'],
		labels1: ['Godina', 'Mjesec', 'Sedmica', 'Dan', 'Sat', 'Minuta', 'Sekunda'],
		labels2: ['Godine', 'Mjeseca', 'Sedmica', 'Dana', 'Sata', 'Minute', 'Sekunde'],
		compactLabels: ['g', 'm', 't', 'd'],
		whichLabels: function(amount) {
			return (amount == 1 ? 1 : (amount >= 2 && amount <= 4 ? 2 : 0));
		},
		digits: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'],
		timeSeparator: ':', isRTL: false};
	$.counddown.seddefaults($.counddown.regional['bs']);
})(jQuery);
