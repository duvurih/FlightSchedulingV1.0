(function () {
    'use strict';
    var controllerId = 'dashboard';
    angular.module('app').controller(controllerId, ['common', 'dataservices', '$filter', 'moment', 'modalPopupFactory', dashboard]);

    function dashboard(common, dataservices, $filter, moment, modalPopupFactory) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        //declaring properties
        vm.news = {
            title: 'iAsset Flight Information',
            description: 'Information about Gate and Flights.'
        };
        vm.messageCount = 0;
        vm.people = [];
        vm.domain = {};
        vm.filterByGateId = 1;
        vm.selectedGateName;
        vm.todayDateTime = new Date();
        vm.title = 'Dashboard';
        vm.dateOptions = {
            'year-format': "'yyyy'",
            'show-weeks': false
        };
        vm.formData = {};
        vm.formData.date = new Date();
        vm.opened = false;
        
        //declaring methods
        vm.filterFlightsByGateId = filterFlightsByGateId;
        vm.filterByDate = filterByDate;
        vm.showFlightInformation = showFlightInformation;
        vm.addNewFlight = addNewFlight;

        //Activation of controller and calling promises
        activate();

        function activate() {
            var promises = [getFlights(), getGates()];
            common.activateController(promises, controllerId)
                .then(function () { 
                    //log('Activated Dashboard View');
                });
        }

        //retrieve all flights
        function getFlights() {
            return dataservices.query('/api/FlightService/GetAllFlights').then(function (data) {
                vm.messageCount = data.length;
                return vm.domain.flights = data;
            })
        }

        //retrieve all gates
        function getGates() {
            return dataservices.query('/api/GateService/GetAllGates').then(function (data) {
                vm.domain.gates = data;
                if (vm.domain.gates != null) {
                    filterFlightsByGateId(1);
                }
                return vm.domain.gates;
            })
        }

        //filter flights baed on gateId
        function filterFlightsByGateId(gateId) {
            vm.filterByGateId = gateId;
            var item = $filter('filter')(vm.domain.gates, { GateID: vm.filterByGateId });
            if (item != 'undefined' || item != null) {
                vm.selectedGateName = item[0].GateName;
            }
            log(vm.selectedGateName + " flights schedule view");
        }

        //filter flights by gateid and date
        function filterByDate(flights) {
            var today = new Date();
            if (vm.formData.date == null || vm.formData.date == '') {
                return flights.GateID == vm.filterByGateId;
            } else {
                var arrivalDate = moment(new Date(flights.ArrivalTime),'MM/DD/YYYY').format('MM/DD/YYYY');
                var compareDate = moment(new Date(vm.formData.date),'MM/DD/YYYY').format('MM/DD/YYYY');
                return flights.GateID == vm.filterByGateId && arrivalDate == compareDate;
            }
        }

        //open a modal dialog for re-scheduling of existing flights
        function showFlightInformation(flightId) {
            var item = $filter('filter')(vm.domain.flights, { FlightID: flightId });
            //var result = modalPopupFactory.openTemplate('md', { flightEdit: true, flight: item, gates: vm.domain.gates, flights: vm.domain.flights }, ROOT + 'app/flight/flight.html', 'flight');
            modalPopupFactory.openTemplate('md', { flightEdit: true, flight: item, gates: vm.domain.gates, flights: vm.domain.flights }, ROOT + 'app/flight/flight.html', 'flight').then(function (result) {
                if (result) {
                    vm.filterFlightsByGateId(vm.filterByGateId);
                }
            });
        }

        //open a modal dialog for new flights
        function addNewFlight() {
            vm.newForm = 'n';
            //var result = modalPopupFactory.openTemplate('md', { flightEdit: false, flight: {}, gates: vm.domain.gates, flights: vm.domain.flights }, ROOT + 'app/flight/flight.html', 'flight');
            modalPopupFactory.openTemplate('md', { flightEdit: false, flight: {}, gates: vm.domain.gates, flights: vm.domain.flights }, ROOT + 'app/flight/flight.html', 'flight').then(function (result) {
                if (result) {
                    vm.filterFlightsByGateId(vm.filterByGateId);
                }
            });
        }
    }
})();