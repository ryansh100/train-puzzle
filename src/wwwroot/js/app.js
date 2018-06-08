/**
 * Parses a Fetch API Response
 * @param {Response} response The Fetch API Response
 * @returns {object} Object from JSON body response.
 */
var parseResponse = function (response) {
    return response.json();
}

// Not as pretty as I might like, 
// but avoiding extra packages and module loaders.
// Webpack would really clean  this up.
var app = new Vue({
    el: '#app',
    data: {
        lineInput: "",
        trainLines: [],
        report: {
            output1: "NO SUCH ROUTE",
            output2: "NO SUCH ROUTE",
            output3: "NO SUCH ROUTE",
            output4: "NO SUCH ROUTE",
            output5: "NO SUCH ROUTE",
            output6: 0,
            output7: 0,
            output8: 0,
            output9: 0,
            output10: 0,
            output1Valid: false,
            output2Valid: false,
            output3Valid: false,
            output4Valid: false,
            output5Valid: false,
            output6Valid: false,
            output7Valid: false,
            output8Valid: false,
            output9Valid: false,
            output10Valid: false
        }
    },
    created: function () {
        this.getTrainLines();
        this.getReport();
    },
    methods: {
        getTrainLines: function () {
            var onData = function (data) {
                this.trainLines = data;
            }
    
            fetch("/api/trainlines")
                .then(parseResponse)
                .then(onData.bind(this))
        },
        getReport: function () {
            
            var onData = function (data) {
                // output 1
                this.report.output1 = data.output1;
                this.report.output1Valid = this.report.output1 === "9";
                // output 2
                this.report.output2 = data.output2;
                this.report.output2Valid = this.report.output2 === "5";
                // output 3
                this.report.output3 = data.output3;
                this.report.output3Valid = this.report.output3 === "13";
                // output 4
                this.report.output4 = data.output4;
                this.report.output4Valid = this.report.output4 === "22";
                // output 5
                this.report.output5 = data.output5;
                this.report.output5Valid = this.report.output5 === "NO SUCH ROUTE";

                // output 6
                this.report.output6 = data.output6;
                this.report.output6Valid = this.report.output6 === 2;
                // output 7
                this.report.output7 = data.output7;
                this.report.output7Valid = this.report.output7 === 3;
                // output 8
                this.report.output8 = data.output8;
                this.report.output8Valid = this.report.output8 === 9;
                // output 9
                this.report.output9 = data.output9;
                this.report.output9Valid = this.report.output9 === 9;
                // output 10
                this.report.output10 = data.output10;
                this.report.output10Valid = this.report.output10 === 7;
            };

            fetch("/api/reports")
                .then(parseResponse)
                .then(onData.bind(this))
        },
        addTrainLine: function (event) {
            var onResponse = function (response) {
                if (response.status === 200) {
                    this.lineInput = "";
                    this.getTrainLines();
                    this.getReport();
                }
            }

            var init = {
                method: "POST",
                headers: {
                    "content-type": "application/json"
                },
                body: JSON.stringify({
                    inputString: this.lineInput
                })
            }
            fetch("/api/trainlines", init)
                .then(onResponse.bind(this))
        },
        removeTrainLine: function(line) {
            var onResponse = function (response) {
                if (response.status === 200) {
                    this.getTrainLines();
                    this.getReport();
                }
            }

            var init = {
                method: "DELETE"
            }
            fetch("/api/trainlines/" + line.id, init)
                .then(onResponse.bind(this))
        }
    }
});
