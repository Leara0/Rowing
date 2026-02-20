DROP TABLE IF EXISTS stroke_phases;
CREATE TABLE stroke_phases(
    phase_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    name NVARCHAR(50) NOT NULL,
    key_focus NVARCHAR(MAX)
);

INSERT INTO stroke_phases (name, key_focus) VALUES
('Catch', 'Blade entry into water with proper body position. Shins vertical, body compressed forward, arms extended.'),

('Drive', 'Power application through legs-body-arms sequence. Legs drive first (60% of power), then body swings back, finally arms pull. Keep blade fully submerged.'),

('Finish', 'Clean blade extraction from water. Handle drawn to lower ribs, body leaning slightly back, legs extended.'),

('Recovery', 'Return to catch position in reverse sequence: arms extend first, body rocks forward, then legs compress. Blade feathered and carried above water.');