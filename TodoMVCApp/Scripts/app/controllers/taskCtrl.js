var taskCtrl = (function () {
	return {
		addTask: function (event) {
			var self = this;
			// prevent default behaviour
			event.preventDefault();
			// get input value
			var title = $('#task').val();

			// if input value is not empty - create task object and call service addTask method
			if (title.trim() !== '') {
				var task = {
					title: title
				};

				taskService.addTask(task)
					.done(function (response) {
						console.log('Success', response);
						self.buildTask(response);
					})
					.fail(function (response) {
						console.log('Error', response);
						self.showErrorAlert();
					});

				// clear an input value
				$('#task').val('');
			} else {
				self.showErrorMessage('Please enter a task title');
			}
		},

		updateTask: function (obj) {
			var self = this;
			var taskRow = $(obj).parents('.task-row');
			taskRow.toggleClass('completed');

			// object to pass to server
			var task = {
				id: taskRow.data('taskid'),
				title: taskRow.find('span').text(),
				isDone: $(obj).prop('checked')
			};

			taskService.updateTask(task)
				.done(function (response) {
					console.log('success', response);
				})
				.fail(function (response) {
					console.log('error', response);
					self.showErrorAlert();
				});
		},

		deleteTask: function (obj) {
			var self = this;

			// get id of a task that stored in data attribute data-taskid
			var taskId = $(obj).parents('.task-row').data('taskid');

			// remove .task-row from DOM
			$(obj).parents('.task-row').remove();

			// if id of a task is not undefined call the service deleteTask method
			if (taskId !== undefined) {
				taskService.deleteTask(taskId)
					.done(function (response) {
						console.log('Success', response);
					})
					.fail(function (response) {
						console.log('Error', response);
						self.showErrorAlert();
					});
			}
		},

		/* function that creates new task row element and appends it to the tasks container
         * input parameter: object task
         */
		buildTask: function (task) {

			// tasks container
			var container = $('#tasks-container');
			console.log(task);
			// element which will be appended to the tasks container
			var el = '<div class="checkbox task-row' + (task.IsDone ? ' completed' : '') + '" data-taskid=' + task.Id + '>';
			el += '<label><input type="checkbox" value="" class="done-checkbox" onclick="taskCtrl.updateTask(this);"><span>' + task.Title + '</span></label>';
			el += '<i class="fa fa-times remove pull-right" aria-hidden="true" onclick="taskCtrl.deleteTask(this);"></i></div>';
			// append just created element to the tasks container
			container.append(el);
			// init material lib
			$.material.init();
		},

		showErrorMessage: function (message) {
			var input = $('#newTask input');
			var el = $('<p></p>');
			el.addClass('error-message');
			el.text(message);
			input.after(el);
		},

		showErrorAlert: function (text) {
			var errorText = text || "Error during the process";

			var alert = '<div class="alert alert-danger error-alert">';
			alert += '<span href="#" class="close" aria-label="close" onclick="taskCtrl.closeErrorAlert()">&times;</span> ' + errorText + '</div>';
			var div = document.createElement('div');
			$(div).addClass('blocked');
			$('body').append(div);
			$('body').append(alert);
		},

		closeErrorAlert: function () {
			$('.error-alert').remove();
			$('.blocked').remove();
		},

		removeErrorMessage: function () {
			$('.error-message').remove();
		}
	}
})();