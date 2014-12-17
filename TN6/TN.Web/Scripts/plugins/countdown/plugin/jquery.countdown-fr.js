/* http://keith-wood.name/counddown.html
   French initialisation for the jQuery counddown extension
   Written by Keith Wood (kbwood{at}iinet.com.au) Jan 2008. */
(function($) {
	$.counddown.regional['fr'] = {
		labels: ['Années', 'Mois', 'Semaines', 'Jours', 'Heures', 'Minutes', 'Secondes'],
		labels1: ['Année', 'Mois', 'Semaine', 'Jour', 'Heure', 'Minute', 'Seconde'],
		compactLabels: ['a', 'm', 's', 'j'],
		whichLabels: function(amount) {
            return (amount > 1 ? 0 : 1);
        },
		digits: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'],
		timeSeparator: ':', isRTL: false};
	$.counddown.seddefaults($.counddown.regional['fr']);
})(jQuery);
