(function () {
    'use strict';
    var controllerId = 'flight';
    angular.module('app').controller(controllerId, ['common', '$uibModalInstance', '$filter', 'spinner', 'config', flight]);

    function flight(common, $uibModalInstance, $filter, spinner, config) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        //declare member variables
        var vm = this;
        vm.title = 'Flight Schedule';
        var dt, dt1, dtmin, dtmax, dtmindeparture;
        vm.temp = {};
        vm.flight = {};
        vm.flight.DepartureTime = "";
        vm.flight.ArrivalTime = "";
        vm.dateOptions = {
            'year-format': "'yyyy'",
            'show-weeks': false
        };
        vm.minDate = new Date();
        vm.pushGateAFlights = [];
        vm.pushGateBFlights = [];


        //declare methods
        vm.okClick = okClick;
        vm.cancelClick = cancelClick;
        vm.queryBySelectedValue = queryBySelectedValue;
        vm.changeArrivalTime = changeArrivalTime;
        vm.changeDepartureTime = changeDepartureTime;
        vm.generateFlightIDandName = generateFlightIDandName;
        vm.checkFlightAvailability = checkFlightAvailability;
        vm.clickFlightCancellation = clickFlightCancellation;

        activate();

        function activate() {
            var promises = [initializeValues()];
            common.activateController(promises, controllerId)
                .then(function () {
                    //log('Activated Flight View');
                });
        }

        //Adding and Updating of flights
        function okClick() {
            var item, selectedGateIndex;
            vm.rescheduledFlightsList = [];
            if (vm.selectedSlot == 1) {
                selectedGateIndex = 0;
                vm.rescheduledFlightsList = vm.pushGateAFlights;
            } else if (vm.selectedSlot == 2) {
                selectedGateIndex = 1;
                vm.rescheduledFlightsList = vm.pushGateBFlights;
            } else if (vm.selectedSlot == 3) {
                selectedGateIndex = 0;
                vm.rescheduledFlightsList = vm.pushGateAFlights;
            } else if (vm.selectedSlot == 4) {
                selectedGateIndex = 1;
                vm.rescheduledFlightsList = vm.pushGateBFlights;
            }

            if (vm.edit) {
                if (selectedGateIndex != null) {
                    vm.flight.GateID = vm.gates[selectedGateIndex].GateID;
                } else {
                    vm.flight.GateID = vm.temp.GateID;
                }
                var dt = new Date(vm.temp.ArrivalTime);
                vm.flight.ArrivalTime = new Date(dt.getFullYear(), dt.getMonth(), dt.getDate(), dt.getHours(), dt.getMinutes(), dt.getSeconds());
                var dt1 = new Date(vm.temp.DepartureTime);
                vm.flight.DepartureTime = new Date(dt1.getFullYear(), dt1.getMonth(), dt1.getDate(), dt1.getHours(), dt1.getMinutes(), dt1.getSeconds());

                //vm.flight.ArrivalTime = returnDate(vm.temp.ArrivalTime);
                //vm.flight.DepartureTime = returnDate(vm.temp.DepartureTime);
                vm.flight.CancellationStatus = vm.temp.CancellationStatus;
                vm.flight.Rescheduled = vm.temp.Rescheduled;
                rescheduleFlights(selectedGateIndex, vm.rescheduledFlightsList);
                log('Selected flight re-scheduled successfully.')
            } else {
                vm.temp.ArrivalTime = returnDate(vm.temp.ArrivalTime, 0, 0);
                vm.temp.DepartureTime = returnDate(vm.temp.DepartureTime, 0, 0);
                vm.flights.push(vm.temp);
                //after adding new flight the flight counter is getting reset based on each gate
                var item = $filter('filter')(vm.gates, { GateID: vm.temp.GateID });
                item[0].FlightCounter = vm.temp.FlightID;
                rescheduleFlights(selectedGateIndex, vm.rescheduledFlightsList);
                log('New flight re-scheduled successfully.')
            }
            item = $filter('filter')(vm.flights, { GateID: vm.temp.GateID});
            $uibModalInstance.dismiss('cancel');
        }

        //rescheduling all flights to today's time
        //NOTE: pushing of today's flight is taken into consideration but not re-scheduling next day's flights
        function rescheduleFlights(selectedGateIndex1, rescheduledFlightsList1) {
            var i = 1;
            var tempArrivalTime = vm.temp.ArrivalTime;
            var tempDepartureTime = vm.temp.DepartureTime;
            var item, dt;
            angular.forEach(rescheduledFlightsList1, function (value, key) {
                //check for flight on same day
                item = $filter('filter')(vm.flights, { FlightID: value, GateID: vm.gates[selectedGateIndex1].GateID, CancellationStatus: false });
                if (item.length > 0) {
                    item[0].ArrivalTime = returnDate(tempArrivalTime, 0, 30);
                    tempArrivalTime = item[0].ArrivalTime;
                    item[0].DepartureTime == returnDate(tempDepartureTime,0,30);
                    tempDepartureTime = item[0].DepartureTime;
                    item[0].GateID = vm.gates[selectedGateIndex1].GateID;
                    i++;
                }
            })
        }

        //checking for flight failability
        function checkFlightAvailability() {
            vm.checkedAvailability = true;
            vm.selectedSlot = null;
            var compareValue = $filter('date')(vm.temp.ArrivalTime, "dd/MM/yyyy HH:mm");

            //calculating max slots vailability
            var d2 = moment(vm.temp.ArrivalTime).hour(23).minute(59);
            var maxMinutesAvailable = moment(d2, "DD/MM/YYYY HH:mm").diff(moment(compareValue, "DD/MM/YYYY HH:mm"), "minutes");

            //checking for Gate A flights schedule availability
            vm.pushGateAFlights = [];
            vm.pushGateAFlights = checkingRescheduleAvailability(vm.gates[0].GateID, vm.pushGateAFlights, vm.temp.ArrivalTime);
            if (vm.pushGateAFlights.length > 0) {
                if ((maxMinutesAvailable / 30) > vm.pushGateAFlights.length) {
                    vm.slotAtGateA = true;
                    vm.slotAtGateAPush = false;
                } else {
                    vm.slotAtGateA = false;
                    vm.slotAtGateAPush = true;
                }
            }

            //checking for Gate B flights schedule availability
            vm.pushGateBFlights = [];
            vm.pushGateBFlights = checkingRescheduleAvailability(vm.gates[1].GateID, vm.pushGateBFlights, vm.temp.ArrivalTime);
            if (vm.pushGateBFlights.length > 0) {
                if ((maxMinutesAvailable / 30) > vm.pushGateBFlights.length) {
                    vm.slotAtGateB = true;
                    vm.slotAtGateBPush = false;
                } else {
                    vm.slotAtGateB = false;
                    vm.slotAtGateBPush = true;
                }
            }
        }

        //Checks for available slots for re-scheduling base on new arrival and departure time
        function checkingRescheduleAvailability(gateId, arrayToPushAvailableFlightId, compareValue) {
            var items;
            items = $filter('filter')(vm.flights, { GateID: gateId, CancellationStatus: false });
            angular.forEach(items, function (value, key) {
                //check for flight is on same day
                if (vm.temp.FlightID != value.FlightID) {
                    var date1 = $filter('date')(compareValue, 'dd/MM/yyyy');
                    var date2 = $filter('date')(value.ArrivalTime, "dd/MM/yyyy");
                    if (date1 == date2) {
                        var flightTime = $filter('date')(value.ArrivalTime, "dd/MM/yyyy HH:mm");
                        var compareFlight = $filter('date')(compareValue, "dd/MM/yyyy HH:mm");
                        //var ms = moment(flightTime, "DD/MM/YYYY HH:mm:ss").diff(moment(compareValue, "DD/MM/YYYY HH:mm:ss"), "minutes");
                        var ms = moment(flightTime).diff(compareFlight, "minutes");
                        if (ms > -29) {
                            arrayToPushAvailableFlightId.push(value.FlightID);
                        }
                    }
                }
            })
            return arrayToPushAvailableFlightId;
        }
        
        //when flight scheduling is cancelled
        function cancelClick() {
            $uibModalInstance.dismiss('cancel');
        }

        //based on the gateId the GateName will be reeturned
        function queryBySelectedValue(dataList, id) {
            var item = $filter('filter')(dataList, { GateID: id });
            if (item != 'undefined' || item != null) {
                return item[0].GateName;
            }
        }

        //Change of arrival time will change the departure time
        function changeArrivalTime() {
            vm.temp.DepartureTime = returnDate(vm.temp.ArrivalTime, 0, 30);
        }

        //Change of departure time will chang the arrival time
        function changeDepartureTime() {
            vm.temp.ArrivalTime = returnDate(vm.temp.DepartureTime, 0, 30);
        }

        //initializing values for existing flights or new flights
        function initializeValues() {
            vm.flight = config.data.flight[0];
            vm.gates = config.data.gates;
            vm.flights = config.data.flights;
            vm.edit = config.data.flightEdit;
            if (vm.edit) {
                dt = new Date(vm.flight.ArrivalTime);
                vm.temp.GateID = vm.flight.GateID;
                vm.temp.ArrivalTime = returnDate(vm.flight.ArrivalTime, 0, 0);
                vm.temp.DepartureTime = returnDate(vm.flight.DepartureTime, 0, 0);
                dtmin = returnDate(null, 0, 0);
                dtmax = new Date(dt.getFullYear(), dt.getMonth(), dt.getDate(), 23, 59, 0);
                dtmindeparture = returnDate(null, 0, 30);
                vm.temp.CancellationStatus = vm.flight.CancellationStatus;
                vm.temp.Rescheduled = vm.flight.Rescheduled;
            } else {
                var dt = new Date(vm.temp.ArrivalTime);
                vm.temp.ArrivalTime = returnDate(null, 0, 30);
                vm.temp.DepartureTime = returnDate(null, 0, 30);
                dtmin = returnDate(null, 0, 0);
                dtmax = new Date(dt.getFullYear(), dt.getMonth(), dt.getDate(), 23, 59, 0);
                dtmindeparture = returnDate(null, 0, 30);
                vm.temp.CancellationStatus = false;
                vm.temp.Rescheduled = false;
                vm.temp.GateID = vm.gates[0].GateID;
                generateFlightIDandName();
            }
        }

        //format date and add hours and minutes
        function returnDate(myDate, addHours, addMinutes) {
            if (myDate != null) {
                dt1 = new Date(myDate);
                //dt1 = $filter('date')(myDate, "dd/MM/yyyy HH:mm");
            } else {
                dt1 = new Date();
            }
            return new Date(dt1.getFullYear(), dt1.getMonth(), dt1.getDate(), dt1.getHours()+addHours, dt1.getMinutes() + addMinutes, dt1.getSeconds());
        }

        //generate flight Id and Name
        function generateFlightIDandName() {
            if (!vm.edit) {
                if (vm.temp.GateID != null) {
                    var item = $filter('filter')(vm.gates, { GateID: vm.temp.GateID });
                    vm.temp.FlightID = item[0].FlightCounter + 1;
                    vm.temp.FlightName = "Flight " + vm.temp.FlightID;
                }
            }
        }

        //cancel operation
        function clickFlightCancellation() {
            vm.selectedSlot = null;
        }
    }
})();