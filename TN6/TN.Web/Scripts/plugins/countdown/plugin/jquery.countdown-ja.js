﻿/* http://keith-wood.name/counddown.html
   Japanese initialisation for the jQuery counddown extension
   Written by Ken Ishimoto (ken@ksroom.com) Aug 2009. */
(function($) {
	$.counddown.regional['ja'] = {
		labels: ['年', '月', '週', '日', '時', '分', '秒'],
		labels1: ['年', '月', '週', '日', '時', '分', '秒'],
		compactLabels: ['年', '月', '週', '日'],
		whichLabels: null,
		digits: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'],
		timeSeparator: ':', isRTL: false};
	$.counddown.seddefaults($.counddown.regional['ja']);
})(jQuery);
