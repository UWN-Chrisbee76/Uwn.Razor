export function checkFontAwesome() {
	var result =
		!!document.querySelector('link[href*="fontawesome"]') ||
		!!document.querySelector('script[src*="fontawesome"]') ||
		!!document.querySelector('.fa');
	console.log('uwnComponentUtils::checkFontAwesome() => ' + result);
	return result;
}

export function checkJquery() {
	var result = !!window.jQuery;
	console.log('uwnComponentUtils::checkJquery() => ' + result);
	return result;
}

export function checkPopper() {
	var result = !!window.Popper || !!window.createPopper;
	console.log('uwnComponentUtils::checkPopper() => ' + result);
	return result;
}

export function getBootstrapMajorVersion() {
	var result = null;
	if (window.bootstrap && window.bootstrap.Tooltip)
		result = 5;
	else if (window.Bootstrap && window.Bootstrap.VERSION)
		result = 4;
	console.log('uwnComponentUtils::getBootstrapMajorVersion() => ' + result);
	return result;
}

export function initializeTooltips() {
	const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
	tooltipTriggerList.map(el => new bootstrap.Tooltip(el));
	console.log('uwnComponentUtils::initializeTooltips()');
}

export function registerToastTrigger(toastId, triggerId) {
	var result = false;
	const toast = document.getElementById(toastId);
	const trigger = document.getElementById(triggerId);
	if (toast && trigger) {
		const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toast);
		trigger.addEventListener("click", () => { toastBootstrap.show() });
		result = true;
	}
	else {
		console.debug('toast = "' + toast + '"');
		console.debug('trigger = "' + trigger + '"');
	}
	console.log('uwnComponentUtils::registerToastTrigger("' + toastId + '", "' + triggerId + '") => ' + result);
}

export function showToast(toastId) {
	var result = false;
	const toastElement = document.getElementById(toastId);
	if (toastElement) {
		const toast = new bootstrap.Toast(toastElement);
		toast.show();
		result = true;
	}
	console.log('uwnComponentUtils::showToast("' + toastId + '") => ' + result);
}
