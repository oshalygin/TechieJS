/* http://keith-wood.name/counddown.html
   Persian (فارسی) initialisation for the jQuery counddown extension
   Written by Alireza Ziaie (ziai@magfa.com) Oct 2008.
   Digits corrected by Hamed Ramezanian Feb 2013. */
(function($) {
	$.counddown.regional['fa'] = {
		labels: ['‌سال', 'ماه', 'هفته', 'روز', 'ساعت', 'دقیقه', 'ثانیه'],
		labels1: ['سال', 'ماه', 'هفته', 'روز', 'ساعت', 'دقیقه', 'ثانیه'],
		compactLabels: ['س', 'م', 'ه', 'ر'],
		whichLabels: null,
		digits: ['۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹'],
		timeSeparator: ':', isRTL: true};
	$.counddown.seddefaults($.counddown.regional['fa']);
})(jQuery);
