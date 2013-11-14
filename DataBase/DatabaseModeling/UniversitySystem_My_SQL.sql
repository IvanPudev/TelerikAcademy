SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `UniversityModel` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `UniversityModel` ;

-- -----------------------------------------------------
-- Table `UniversityModel`.`Faculties`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `UniversityModel`.`Faculties` (
  `ID` INT NOT NULL ,
  `FacultiesName` VARCHAR(45) NULL ,
  PRIMARY KEY (`ID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityModel`.`Students`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `UniversityModel`.`Students` (
  `ID` INT NOT NULL ,
  `FirstNAme` VARCHAR(45) NULL ,
  `LastName` VARCHAR(45) NULL ,
  `Faculties_ID` INT NOT NULL ,
  `Faculties_ID1` INT NOT NULL ,
  PRIMARY KEY (`ID`, `Faculties_ID`) ,
  INDEX `fk_Students_Faculties1_idx` (`Faculties_ID1` ASC) ,
  CONSTRAINT `fk_Students_Faculties1`
    FOREIGN KEY (`Faculties_ID1` )
    REFERENCES `UniversityModel`.`Faculties` (`ID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityModel`.`Courses`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `UniversityModel`.`Courses` (
  `ID` INT NOT NULL ,
  `Name` VARCHAR(45) NULL ,
  PRIMARY KEY (`ID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityModel`.`Departments`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `UniversityModel`.`Departments` (
  `ID` INT NOT NULL ,
  `Name` VARCHAR(45) NULL ,
  `Faculties_ID` INT NOT NULL ,
  `Faculties_ID1` INT NOT NULL ,
  PRIMARY KEY (`ID`, `Faculties_ID`) ,
  INDEX `fk_Departments_Faculties1_idx` (`Faculties_ID1` ASC) ,
  CONSTRAINT `fk_Departments_Faculties1`
    FOREIGN KEY (`Faculties_ID1` )
    REFERENCES `UniversityModel`.`Faculties` (`ID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityModel`.`Professors`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `UniversityModel`.`Professors` (
  `ID` INT NOT NULL ,
  `ProfessorsName` VARCHAR(45) NULL ,
  `Departments_ID` INT NOT NULL ,
  `Departments_Faculties_ID` INT NOT NULL ,
  `Courses_ID` INT NOT NULL ,
  PRIMARY KEY (`ID`) ,
  INDEX `fk_Professors_Departments1_idx` (`Departments_ID` ASC, `Departments_Faculties_ID` ASC) ,
  INDEX `fk_Professors_Courses1_idx` (`Courses_ID` ASC) ,
  CONSTRAINT `fk_Professors_Departments1`
    FOREIGN KEY (`Departments_ID` , `Departments_Faculties_ID` )
    REFERENCES `UniversityModel`.`Departments` (`ID` , `Faculties_ID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Professors_Courses1`
    FOREIGN KEY (`Courses_ID` )
    REFERENCES `UniversityModel`.`Courses` (`ID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityModel`.`Titles`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `UniversityModel`.`Titles` (
  `ID` INT NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NULL ,
  PRIMARY KEY (`ID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityModel`.`Courses_has_Students`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `UniversityModel`.`Courses_has_Students` (
  `Courses_ID` INT NOT NULL ,
  `Students_ID` INT NOT NULL ,
  `Students_Faculties_ID` INT NOT NULL ,
  PRIMARY KEY (`Courses_ID`, `Students_ID`, `Students_Faculties_ID`) ,
  INDEX `fk_Courses_has_Students_Students1_idx` (`Students_ID` ASC, `Students_Faculties_ID` ASC) ,
  INDEX `fk_Courses_has_Students_Courses1_idx` (`Courses_ID` ASC) ,
  CONSTRAINT `fk_Courses_has_Students_Courses1`
    FOREIGN KEY (`Courses_ID` )
    REFERENCES `UniversityModel`.`Courses` (`ID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Courses_has_Students_Students1`
    FOREIGN KEY (`Students_ID` , `Students_Faculties_ID` )
    REFERENCES `UniversityModel`.`Students` (`ID` , `Faculties_ID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityModel`.`Titles_has_Professors`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `UniversityModel`.`Titles_has_Professors` (
  `Titles_ID` INT NOT NULL ,
  `Professors_ID` INT NOT NULL ,
  PRIMARY KEY (`Titles_ID`, `Professors_ID`) ,
  INDEX `fk_Titles_has_Professors_Professors1_idx` (`Professors_ID` ASC) ,
  INDEX `fk_Titles_has_Professors_Titles1_idx` (`Titles_ID` ASC) ,
  CONSTRAINT `fk_Titles_has_Professors_Titles1`
    FOREIGN KEY (`Titles_ID` )
    REFERENCES `UniversityModel`.`Titles` (`ID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Titles_has_Professors_Professors1`
    FOREIGN KEY (`Professors_ID` )
    REFERENCES `UniversityModel`.`Professors` (`ID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `UniversityModel` ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
