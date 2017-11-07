var taskService = (function () {
	return {
		addTaskUrl: config.addTaskUrl,
		updateTaskUrl: config.updateTaskUrl,
		deleteTaskUrl: config.deleteTaskUrl,
		addTask: function (task) {
			var self = this;
			var ajax = $.ajax({
				url: self.addTaskUrl,
				type: 'POST',
				data: task
			});
			return ajax;
		},
		deleteTask: function (taskId) {
			var self = this;
			var ajax = $.ajax({
				url: self.deleteTaskUrl +'/'+taskId,
				type: 'GET'
			});
			return ajax;
		},
		updateTask: function (task) {
			var self = this;
			var ajax = $.ajax({
				url: self.updateTaskUrl,
				type: 'POST',
				data: task
			});
			return ajax;
		}
	}
})();