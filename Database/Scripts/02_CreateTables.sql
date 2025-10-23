USE Rowing;
GO

-- Drop tables if they exist (in reverse order of dependencies)
IF OBJECT_ID('dbo.common_errors', 'U') IS NOT NULL DROP TABLE dbo.common_errors;
IF OBJECT_ID('dbo.technique_drills', 'U') IS NOT NULL DROP TABLE dbo.technique_drills;
IF OBJECT_ID('dbo.injury_prevention', 'U') IS NOT NULL DROP TABLE dbo.injury_prevention;
IF OBJECT_ID('dbo.stroke_phases', 'U') IS NOT NULL DROP TABLE dbo.stroke_phases;
GO

CREATE TABLE stroke_phases(
                              phase_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
                              name NVARCHAR(50) NOT NULL,
                              key_focus NVARCHAR(MAX)
);

CREATE TABLE injury_prevention (
                                   prevention_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
                                   body_area NVARCHAR(50) NOT NULL,
                                   injury_type NVARCHAR(100),
                                   prevention_strategy NVARCHAR(MAX),
                                   strengthening_exercises NVARCHAR(MAX),
                                   critical_phase_id INT,
                                   is_verified BIT,
                                   created_at DATETIME2 DEFAULT GETDATE(),
                                   created_by NVARCHAR(50),
                                   FOREIGN KEY (critical_phase_id) REFERENCES stroke_phases(phase_id)
);

CREATE TABLE technique_drills (
                                  drill_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
                                  name NVARCHAR(100) NOT NULL,
                                  focus_area NVARCHAR(50),
                                  description NVARCHAR(MAX),
                                  execution_steps NVARCHAR(MAX),
                                  coaching_points NVARCHAR(MAX),
                                  progression NVARCHAR(MAX),
                                  is_verified BIT,
                                  created_at DATETIME2 DEFAULT GETDATE(),
                                  created_by NVARCHAR(50)
);

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
GO

