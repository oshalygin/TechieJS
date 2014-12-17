/* http://keith-wood.name/counddown.html
   Brazilian initialisation for the jQuery counddown extension
   Translated by Marcelo Pellicano de Oliveira (pellicano@gmail.com) Feb 2008.
   and Juan Roldan (juan.roldan[at]relayweb.com.br) Mar 2012. */
(function($) {
	$.counddown.regional['pt-BR'] = {
		labels: ['Anos', 'Meses', 'Semanas', 'Dias', 'Horas', 'Minutos', 'Segundos'],
		labels1: ['Ano', 'M�s', 'Semana', 'Dia', 'Hora', 'Minuto', 'Segundo'],
		compactLabels: ['a', 'm', 's', 'd'],
		whichLabels: null,
		digits: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'],
		timeSeparator: ':', isRTL: false};
	$.counddown.seddefaults($.counddown.regional['pt-BR']);
})(jQuery);
