(function () {

    "use strict";
    var factoryId = 'modalPopupFactory';

    angular.module('app').factory(factoryId, ['$uibModal','config', modalPopupFactory]);

    function modalPopupFactory($uibModal, config) {
        var factory = {
            openTemplate: openTemplate
        };
        return factory;

        function openTemplate(size, data, tmplUrl, controller) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: tmplUrl,
                controller: controller,
                controllerAs: 'vm',
                backdrop: 'static',
                size: size,
                resolve: {
                    config: function () {
                        return {
                            data: data
                        };
                    }
                }
            });

            return modalInstance.result;
        }
    }

})();
