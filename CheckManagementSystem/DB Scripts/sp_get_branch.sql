DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_get_branch` $$
CREATE PROCEDURE `sp_get_branch`()
BEGIN
  -- Created by Vijayavel 21-01-2021
  SELECT
    branch_code,branch_name,concat(branch_name,'-',branch_code) as branch
  from cms_mst_branchmaster order by branch_name;
END $$

DELIMITER ;