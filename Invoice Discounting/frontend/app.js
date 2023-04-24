Dropzone.autoDiscover = false;
        $(document).ready(function () {

            $('.js-my-select').select2({
				minimumResultsForSearch: -1
			}

			);

            $("#dZUpload").dropzone({
                url: "hn_SimpeFileUploader.ashx",
                addRemoveLinks: true,
                success: function (file, response) {
                    var imgName = response;
                    file.previewElement.classList.add("dz-success");
                    console.log("Successfully uploaded :" + imgName);
                },
                error: function (file, response) {
                    file.previewElement.classList.add("dz-error");
                }
            });
        });


var addField = new Vue({
    el: '.js-add-field',
    data: {
        fields: [],
        fieldName: '',
        inputType: 'file',
        fieldNameError: false, 
        itemLength: 1,
    },
    methods: {
        addField: function () {
            if (this.fieldName) {
                this.fields.push({
                    fieldName: this.fieldName,
                    inputType: this.inputType
                })
                this.fieldNameError = false;
                this.fieldName = '';

            } else {
                this.fieldNameError = true
            }
        }
    }
})
