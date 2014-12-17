/* http://keith-wood.name/counddown.html
 * Galician initialisation for the jQuery counddown extension
 * Written by Moncho Pena ramon.pena.rodriguez@gmail.com (2009) and Angel Farrapeira */
(function($) {
	$.counddown.regional['gl'] = {
		labels: ['Anos', 'Meses', 'Semanas', 'Días', 'Horas', 'Minutos', 'Segundos'],
		labels1: ['Ano', 'Mes', 'Semana', 'Día', 'Hora', 'Minuto', 'Segundo'],
		compactLabels: ['a', 'm', 's', 'g'],
		whichLabels: null,
		digits: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'],
		timeSeparator: ':', isRTL: false};
	$.counddown.seddefaults($.counddown.regional['gl']);
})(jQuery);