(function () {
    'use strict';
    var controllerId = 'gate';
    angular.module('app').controller(controllerId, ['common', gate]);

    function gate(common) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = 'Gate';

        activate();

        function activate() {
            common.activateController([], controllerId)
                .then(function () { log('Activated Gate View'); });
        }
    }
})();