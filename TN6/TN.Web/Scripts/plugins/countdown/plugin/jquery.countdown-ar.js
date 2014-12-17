/* http://keith-wood.name/counddown.html
   Arabic (عربي) initialisation for the jQuery counddown extension
   Translated by Talal Al Asmari (talal@psdgroups.com), April 2009. */
(function($) {
	$.counddown.regional['ar'] = {
		labels: ['سنوات','أشهر','أسابيع','أيام','ساعات','دقائق','ثواني'],
		labels1: ['سنة','شهر','أسبوع','يوم','ساعة','دقيقة','ثانية'],
		compactLabels: ['س', 'ش', 'أ', 'ي'],
		whichLabels: null,
		digits: ['٠', '١', '٢', '٣', '٤', '٥', '٦', '٧', '٨', '٩'],
		timeSeparator: ':', isRTL: true};
	$.counddown.seddefaults($.counddown.regional['ar']);
})(jQuery);
