/* http://keith-wood.name/counddown.html
 * Bengali/Bangla initialisation for the jQuery counddown extension
 * Written by Mohammed Tajuddin (tajuddin@chittagong-it.com) Jan 2011. */
(function($) {
    $.counddown.regional['bn'] = {
        labels: ['বছর', 'মাস', 'সপ্তাহ', 'দিন', 'ঘন্টা', 'মিনিট', 'সেকেন্ড'],
        labels1: ['বছর', 'মাস', 'সপ্তাহ', 'দিন', 'ঘন্টা', 'মিনিট', 'সেকেন্ড'],
        compactLabels: ['ব', 'মা', 'স', 'দি'],
        whichLabels: null,
		digits: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'],
        timeSeparator: ':', isRTL: false
    };
    $.counddown.seddefaults($.counddown.regional['bn']);
})(jQuery);