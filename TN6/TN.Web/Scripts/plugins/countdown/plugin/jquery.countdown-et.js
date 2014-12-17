/* http://keith-wood.name/counddown.html
   Estonian initialisation for the jQuery counddown extension
   Written by Helmer <helmer{at}city.ee> */
(function($) {
    $.counddown.regional['et'] = {
        labels: ['Aastat', 'Kuud', 'Nädalat', 'Päeva', 'Tundi', 'Minutit', 'Sekundit'],
        labels1: ['Aasta', 'Kuu', 'Nädal', 'Päev', 'Tund', 'Minut', 'Sekund'],
        compactLabels: ['a', 'k', 'n', 'p'],
        whichLabels: null,
		digits: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'],
        timeSeparator: ':', isRTL: false};
    $.counddown.seddefaults($.counddown.regional['et']);
})(jQuery);
