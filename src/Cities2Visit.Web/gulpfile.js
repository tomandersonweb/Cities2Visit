/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var browserify = require('gulp-browserify');
var concat = require('gulp-concat');
var inject = require('gulp-inject');
var rename = require("gulp-rename");
var uglify = require("gulp-uglify");

gulp.task('browserify', function () {
    gulp.src(['wwwroot/app.js'])
    .pipe(browserify({
        insertGlobals: true,
        debug: true
    }))
    .pipe(concat('bundle.js'))
    .pipe(gulp.dest('wwwroot/dist/js'));
});

var jsSource = "wwwroot/app/**/*.js",
    jsDestination = "wwwroot/dist/js";

gulp.task("bundle-app", function () {
    return gulp.src(jsSource)
        .pipe(concat("app-bundle.js"))
        .pipe(gulp.dest(jsDestination))
        .pipe(rename("app-bundle.min.js"))
        .pipe(uglify())
        .pipe(gulp.dest(jsDestination));
});

gulp.task('default', ['browserify', 'bundle-app']);