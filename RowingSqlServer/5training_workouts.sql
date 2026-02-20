USE rowing;

-- Drop table if exists
IF OBJECT_ID('training_workouts', 'U') IS NOT NULL
    DROP TABLE training_workouts;

-- Create table
CREATE TABLE training_workouts (
    workout_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    workout_type NVARCHAR(50),
    duration_minutes INT,
    intensity_level NVARCHAR(20),
    description NVARCHAR(MAX),
    target_stroke_rate NVARCHAR(50),
    training_goal NVARCHAR(MAX),
    is_verified BIT,
    created_at DATETIME2 DEFAULT GETDATE(),
    created_by NVARCHAR(50)
);

-- Insert data
INSERT INTO training_workouts (name, workout_type, duration_minutes, intensity_level, description, target_stroke_rate, training_goal, is_verified, created_at, created_by) VALUES
('Steady State Base', 'Aerobic', 45, 'Moderate', '45 minutes continuous rowing at steady pace with good technique focus', '18-22 SPM', 'Build aerobic base, technique refinement, endurance', 1, GETDATE(), 'system'),
('Rate Pyramid', 'Mixed', 21, 'Moderate', '1 min intervals: 16/20/18/22/20/24/22/26/18/22/20/24/22/26/24/28', 'Variable', 'Stroke rate control, technique at different rates', 1, GETDATE(), 'system'),
('UT2 Long Piece', 'Aerobic', 60, 'Low-Moderate', '60 minutes at 65-75% max heart rate, focus on technique and rhythm', '18-20 SPM', 'Aerobic capacity, technique endurance, fat burning', 1, GETDATE(), 'system'),
('AT Threshold', 'Anaerobic Threshold', 25, 'High', '4 x 5 minutes at 80-85% max heart rate, 2 min rest between pieces', '22-26 SPM', 'Lactate threshold, sustained high intensity', 1, GETDATE(), 'system'),
('Speed Intervals', 'Speed/Power', 24, 'Very High', '8 x 30 seconds all-out, 2 minutes easy recovery between', '28-32 SPM', 'Neuromuscular power, high-rate technique, speed', 1, GETDATE(), 'system'),
('Technique Focus', 'Technical', 20, 'Low', 'Pick drills: arms only, arms+body, full stroke. 5 min each x 4', '16-20 SPM', 'Movement pattern refinement, sequencing, form', 1, GETDATE(), 'system'),
('2K Test Prep', 'Race Simulation', 30, 'Very High', '4 x 500m at 2K pace, 3 min rest. Warm-up and cool-down included', '26-30 SPM', 'Race pace practice, mental preparation, speed endurance', 1, GETDATE(), 'system');