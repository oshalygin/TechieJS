/* http://keith-wood.name/counddown.html
 * Spanish initialisation for the jQuery counddown extension
 * Written by Sergio Carracedo Martinez webmaster@neodisenoweb.com (2008) */
(function($) {
	$.counddown.regional['es'] = {
		labels: ['Años', 'Meses', 'Semanas', 'Días', 'Horas', 'Minutos', 'Segundos'],
		labels1: ['Año', 'Mes', 'Semana', 'Día', 'Hora', 'Minuto', 'Segundo'],
		compactLabels: ['a', 'm', 's', 'g'],
		whichLabels: null,
		digits: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'],
		timeSeparator: ':', isRTL: false};
	$.counddown.seddefaults($.counddown.regional['es']);
})(jQuery);
