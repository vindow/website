'use strict';

module.exports = (sequelize, type) => {
	// Followee follows the followed
	return sequelize.define('follow', {
		notifyOn: {
			type: type.SMALLINT,
			defaultValue: 0,
		},
	});
};