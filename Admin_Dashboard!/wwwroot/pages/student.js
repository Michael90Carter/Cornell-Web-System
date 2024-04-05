

const myModal = new bootstrap.Modal('#add-student-button');
setTimeout(() => {
	myModal.hide();
}, 3000000);

















/*"use strict";

//class def

const StudentAdd = function () {

	const addStudent = () => {
		document.getElementById('add-student-button').addEventListener('click', () => {
			var newModal1 = new bootstrap.Modal(document.getElementById('add_student_modal'), {
				backdrop: 'static',
				Keyboard: false
			});
			newModal1.show();
		});

		
		document.getElementById('add-student-form').addEventListener('submit', (e) => {
			e.preventDefault();
			const form = document.addstudentform;
			if (form.checkValidity() === false) {
				e.stopPropagation();
				form.classList.add('was-validated');
				return;
			}

			form.classList.add('was-validated');

			document.getElementById("add-student-submit-button").setAttribute("disabled", true);
			document.getElementById('add-student-submit-button').innerHTML = `<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Processing...`;

			const formData = new URLSearchParams();
			for (const pair of new FormData(form)) {
				formData.append(pair[0], pair[1]);
			}

			fetch('/students/add', {
				method: 'POST',
				body: formData

			}).then((response) => response.json()).
				then((data) => {
					if (!!data) {
						if (data.status == 'success') {
							form.reset();
						} else {

						}

					} else {

					}
					document.getElementById("add-student-submit-button").removeAttribute("disabled");
					document.getElementById("add-student-submit-button").innerHTML = `Add Product`;
				});
		});
	};

	return {
		init: () => {
			addStudent();
		}
	}
}();

$(document).ready(function () {
	if (document.getElementById('students-datatable') != null) {
		StudentAdd.init();
	}

});*/