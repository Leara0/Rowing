DROP TABLE IF EXISTS common_errors;

CREATE TABLE common_errors ( 
    error_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    description NVARCHAR(MAX),
    phase_id INT,
    cause NVARCHAR(MAX),
    correction_strategy NVARCHAR(MAX),
    related_injury_id INT,
    is_verified BIT,
    created_at DATETIME2 DEFAULT GETDATE(), 
    created_by NVARCHAR(50),
    FOREIGN KEY (phase_id) REFERENCES stroke_phases(phase_id),
    FOREIGN KEY (related_injury_id) REFERENCES injury_prevention(prevention_id)
);

INSERT INTO common_errors (name, description, phase_id, cause, correction_strategy, related_injury_id, is_verified, created_at, created_by) VALUES
('Sky Catching', 'Blade enters water too high above surface, reducing effective stroke length', 1, 'Poor timing, reaching too far forward, weak core position', 'Focus on blade control, proper body compression, hands-first movement', 4, 1, GETDATE(), 'system'),
('Over-compression', 'Knees bend too much at catch, creating weak position for power application', 1, 'Flexibility limitations, trying to get too much length', 'Find optimal compression for individual flexibility, strengthen hip flexors', 2, 1, GETDATE(), 'system'),
('Bum Shoving', 'Seat moves faster than shoulders during drive, breaking proper leg-body-arms sequence', 2, 'Weak leg drive, poor connection, fatigue', 'Practice legs-only drills, focus on staying connected through footplate', 1, 1, GETDATE(), 'system'),
('Opening Body Too Early', 'Body swings back before legs complete their drive', 2, 'Impatience, weak leg strength, poor sequencing understanding', 'Legs-body-arms sequence drills, strengthen leg drive', 1, 1, GETDATE(), 'system'),
('Washing Out', 'Blade lifts from water before completing full stroke', 3, 'Handle pulled down instead of through body, weak finish position', 'Draw handle to lower ribs, maintain body angle, clean extraction', 4, 1, GETDATE(), 'system'),
('Rushing the Slide', 'Moving too quickly during recovery, disrupting rhythm and boat balance', 4, 'Anxiety, lack of rhythm awareness, poor ratio understanding', 'Practice 1:2 drive to recovery ratio, focus on controlled movement forward', 1, 1, GETDATE(), 'system');
